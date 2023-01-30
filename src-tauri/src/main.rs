#![cfg_attr(
    all(not(debug_assertions), target_os = "windows"),
    windows_subsystem = "windows"
)]

mod format;
mod video;

use crate::{format::get_supported_pixel_formats, video::validate_video};

fn main() {
    tauri::Builder::default()
        .invoke_handler(tauri::generate_handler![
            validate_video,
            get_supported_pixel_formats
        ])
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
