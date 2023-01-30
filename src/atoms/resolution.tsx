import { atom, PrimitiveAtom } from "jotai";

export type Resolution = {
  width: number;
  height: number;
};

export const Resolution: PrimitiveAtom<Resolution> = atom({
  width: 1920,
  height: 1080,
});
