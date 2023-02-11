import {atom} from "jotai"


export const BuiltinModels: Array<string> = [
    "vmaf_float_v0.6.1",
    "vmaf_float_v0.6.1neg",
    "vmaf_float_4k_v0.6.1",
    "vmaf_v0.6.1",
    "vmaf_v0.6.1neg",
    "vmaf_4k_v0.6.1",
    "vmaf_4k_v0.6.1neg",
  ];

export let modelAtom = atom(BuiltinModels[0]);