use egui_file::FileDialog;
use std::{
    path::{Path, PathBuf},
    sync::Arc,
};

use eframe::{
    egui::{CentralPanel, ProgressBar, Ui},
    epaint::mutex::Mutex,
};
use libvmaf_rs::vmaf::Vmaf;

pub struct VmafApp {
    vmaf: Arc<Mutex<Vmaf>>,
    ref_path: Option<PathBuf>,
    dist_path: Option<PathBuf>,
    progress: Option<Arc<indicatif::ProgressBar>>,
    scores: Option<Arc<Mutex<Vec<f64>>>>,
    show_about: bool,
    ref_file_dialog: Option<FileDialog>,
    dist_file_dialog: Option<FileDialog>
}

impl VmafApp {
    pub fn new() -> VmafApp {
        let vmaf = Vmaf::new(
            libvmaf_rs::libvmaf_sys::VmafLogLevel::VMAF_LOG_LEVEL_DEBUG,
            num_cpus::get() as u32,
            0,
            0,
        )
        .unwrap();

        VmafApp {
            vmaf: Arc::new(Mutex::new(vmaf)),
            ref_path: None,
            dist_path: None,
            progress: None,
            scores: None,
            show_about: false,
            ref_file_dialog: None,
            dist_file_dialog: None
        }
    }

    pub fn draw_setup(&mut self, ui: &mut Ui) {

        if let Some(dialog) = &mut self.ref_file_dialog{
            todo!()
        }

        ui.heading("Vmaf Gui");

        ui.vertical(|ui| {
            ui.label("Reference");
            if self.ref_path.is_none() {
                if ui.button("Open File").clicked() {
                    let mut dialog = FileDialog::open_file(self.ref_path.clone());
                    FileDialog::open(&mut dialog);
                    self.ref_file_dialog = Some(dialog);
                }
            }
            ui.label("Distorted");
        });
    }
}

impl eframe::App for VmafApp {
    fn update(&mut self, ctx: &eframe::egui::Context, frame: &mut eframe::Frame) {
        CentralPanel::default().show(ctx, |ui| self.draw_setup(ui));
        //todo!()
    }
}
