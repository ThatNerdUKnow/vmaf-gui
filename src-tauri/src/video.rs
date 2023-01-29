use std::{panic, thread};

use libvmaf_rs::video::Video;

#[tauri::command]
pub async fn validate_video(path: String) -> Result<(), String> {
    let did_panic = thread::spawn(|| match Video::new(path, 640, 480) {
        Ok(_) => Ok(()),
        Err(e) => Err(e.frames().into_iter().map(|f| format!("{f:?}")).fold(
            String::new(),
            |mut prev, next| {
                prev.push_str(&next);
                prev.push_str("\n");
                prev
            },
        )),
    });

    match did_panic.join() {
        Ok(e) => e,
        Err(e) => Err("Panicked while trying to load video".to_string()),
    }
}
