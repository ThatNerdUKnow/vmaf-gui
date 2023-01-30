import { basename } from "@tauri-apps/api/path";
import { Atom, atom, Getter, PrimitiveAtom } from "jotai";

const ReferenceFullPath = atom("");
const ReferenceFileName = atom(getBaseName(ReferenceFullPath));
const DistortedFullPath = atom("");
const DistortedFileName = atom(getBaseName(DistortedFullPath));

export type VideoPath = {
  fullPath: PrimitiveAtom<string>;
  fileName: Atom<Promise<string>>;
};

export const ReferencePath: VideoPath = {
  fullPath: ReferenceFullPath,
  fileName: ReferenceFileName,
};

export const DistortedPath: VideoPath = {
  fullPath: DistortedFullPath,
  fileName: DistortedFileName,
};

function getBaseName(fullPathAtom: PrimitiveAtom<string>) {
  return async (get: Getter) => {
    let fullPath = get(fullPathAtom);
    let fileName = await basename(fullPath);
    return fileName;
  };
}
