import { Form } from "react-bootstrap";
import ResolutionOption, { ResolutionOptionProps } from "./resolutionOption";

const resolutions: Array<ResolutionOptionProps> = [
  { width: 3840, height: 2160 },
  { width: 2560, height: 1440 },
  { width: 1920, height: 1080 },
  { width: 1280, height: 720 },
];

function ResolutionSelect() {
  return (
    <Form.Group className="mb-3">
      <Form.Label>Resolution</Form.Label>
      <Form.Select>
        {resolutions.map((r) => (
          <ResolutionOption width={r.width} height={r.height} />
        ))}
        <option>custom</option>
      </Form.Select>
    </Form.Group>
  );
}

export default ResolutionSelect;
