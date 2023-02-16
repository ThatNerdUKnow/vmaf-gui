import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { Col, Row } from "react-bootstrap";
import FileSelect from "./fileSelect";
import ResolutionSelect from "./resolutionSelect";
import PixelFormatSelect from "./pixelFormatSelect";
import { ChangeEvent, FormEvent, Suspense, useState } from "react";
import { ReferencePath, DistortedPath } from "../../atoms/videos";
import ModelSelect from "./modelSelect";

function VmafConfigForm() {

  const [bitDepth,setBitDepth] = useState(8);

  function handleBitDepthChange(event: ChangeEvent<HTMLSelectElement>){
    let value = parseInt(event.target.value);
    setBitDepth(value);
  }

  function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();
  }

  return (
    <Form onSubmit={handleSubmit}>
      <Row>
        <Col>
          <Suspense>
            <FileSelect path={ReferencePath} type="Reference" />
          </Suspense>
        </Col>

        <Col>
          <Suspense>
            <FileSelect path={DistortedPath} type="Distorted" />
          </Suspense>
        </Col>
      </Row>

      <Row>
        <ResolutionSelect />
      </Row>

      <Row>
        <Col>
          <PixelFormatSelect />
        </Col>
        <Col>
          <Form.Group className="mb-3">
            <Form.Label>Bit Depth</Form.Label>
            <Form.Select value={bitDepth} onChange={handleBitDepthChange}>
              <option>8</option>
              <option>10</option>
              <option>12</option>
            </Form.Select>
          </Form.Group>
        </Col>
      </Row>

      <Form.Group className="mb-3">
        <ModelSelect/>
      </Form.Group>

      <Button type="submit">Get VMAF Scores</Button>
    </Form>
  );
}

export default VmafConfigForm;
