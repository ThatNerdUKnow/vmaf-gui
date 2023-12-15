use eframe::{run_native, NativeOptions};
use vmaf_gui::VmafApp;

fn main() {
    run_native("Vmaf-Gui", NativeOptions::default(), Box::new(|_cc|Box::new(VmafApp::new()))).unwrap();
}
