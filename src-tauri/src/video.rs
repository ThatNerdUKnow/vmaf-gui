use libvmaf_rs::video::Video;
use std::path::Path;

#[tauri::command]
pub async fn validate_video(path: &str) -> Result<(), String> {
    match Video::new(path, 640, 480) {
        Ok(_) => Ok(()),
        Err(e) => Err(e.to_string()),
    }
}
