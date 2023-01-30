use libvmaf_rs::video::Video;

#[tauri::command]
pub async fn validate_video(path: String) -> Result<(), String> {
    match Video::new(path, 640, 480) {
        Ok(_) => Ok(()),
        Err(e) => Err(e.frames().into_iter().map(|f| format!("{f:?}")).fold(
            String::new(),
            |mut prev, next| {
                prev.push_str(&next);
                prev.push_str("\n");
                prev
            },
        )),
    }
}
