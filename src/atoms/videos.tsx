import { basename } from "@tauri-apps/api/path";
import { atom, Getter, PrimitiveAtom } from "jotai";

export const ReferenceFullPath = atom("");
export const ReferenceFileName = atom(getBaseName(ReferenceFullPath));
export const DistortedFullPath = atom("");
export const DistortedFileName = atom(getBaseName(DistortedFullPath))

function getBaseName(fullPathAtom: PrimitiveAtom<string>) {
    return async(get: Getter)=>{
        let fullPath = get(fullPathAtom)
        let fileName = await basename(fullPath)
        return fileName;
    }
}
