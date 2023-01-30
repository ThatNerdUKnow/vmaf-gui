import { Form } from "react-bootstrap";
import { invoke } from "@tauri-apps/api";
import { useEffect, useState } from "react";

function PixelFormatSelect() {
  const [formats, setFormats] = useState<Array<string>>([]);

  useEffect(() => {
    async function getPixelFormats() {
      const _formats = await invoke<Array<string>>(
        "get_supported_pixel_formats"
      );

      setFormats(_formats);
    }
    getPixelFormats();
  }, []);
  return (
    <Form.Group className="mb-3">
      <Form.Label>Pixel Format</Form.Label>
      <Form.Select>
        {formats.map((format, i) => (
          <option key={i} value={format}>
            {format}
          </option>
        ))}
      </Form.Select>
    </Form.Group>
  );
}

export default PixelFormatSelect;
