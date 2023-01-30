use serde::{Deserialize, Serialize};
use strum::IntoEnumIterator;
use strum_macros::{Display, EnumIter};

#[derive(EnumIter, Display, Serialize, Deserialize)]
pub enum PixFormat {
    YUV444P,
    YUV422P,
    YUV420P,
}

#[tauri::command]
pub fn get_supported_pixel_formats() -> Vec<PixFormat> {
    PixFormat::iter().collect()
}
