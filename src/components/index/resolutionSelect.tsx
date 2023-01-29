import { Form } from "react-bootstrap";
import ResolutionOption, { ResolutionOptionProps } from "./resolutionOption";
import { ChangeEvent, ChangeEventHandler, useState } from "react";

const resolutions: Array<ResolutionOptionProps> = [
  { width: 3840, height: 2160 },
  { width: 2560, height: 1440 },
  { width: 1920, height: 1080 },
  { width: 1280, height: 720 },
];

function ResolutionSelect() {
  const [isCustomSelected, setIsCustomSelected] = useState(false);
  const [value, setValue] = useState(JSON.stringify(resolutions[2]));

  function handleChange(event: ChangeEvent<HTMLSelectElement>) {
    switch (event.target.value) {
      case "custom":
        setIsCustomSelected(true);
        break;
      default:
        setValue(event.target.value);
    }
  }

  return (
    <Form.Group className="mb-3">
      <Form.Label>Resolution</Form.Label>
      <Form.Select onChange={handleChange} value={value}>
        {resolutions.map((r, i) => (
          <ResolutionOption key={i} width={r.width} height={r.height} />
        ))}
      </Form.Select>
    </Form.Group>
  );
}

export default ResolutionSelect;
