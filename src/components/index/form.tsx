function Form() {
  return (
    <form>
      <label className="label" htmlFor="reference">
        <span className="label-text">Reference</span>
      </label>
      <input
        id="reference"
        type="file"
        className="file-input file-input-bordered w-full max-w-xs"
      />

      <label className="label" htmlFor="distorted">
        <span className="label-text">Distorted</span>
      </label>
      <input
        id="distorted"
        type="file"
        className="file-input file-input-bordered w-full max-w-xs"
      />

      <div className="divider"></div>
      <button className="btn">Get VMAF Scores</button>
    </form>
  );
}

export default Form;
