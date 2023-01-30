import { Resolution } from "../../atoms/resolution";

function ResolutionOption(resolution: Resolution) {
  return (
    <option value={JSON.stringify(resolution)}>
      {resolution.width}x{resolution.height}
    </option>
  );
}

export default ResolutionOption;
