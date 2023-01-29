export type ResolutionOptionProps = {
  width: number;
  height: number;
};

function ResolutionOption(resolution: ResolutionOptionProps) {
  return (
    <option value={JSON.stringify(resolution)}>
      {resolution.width}x{resolution.height}
    </option>
  );
}

export default ResolutionOption;
