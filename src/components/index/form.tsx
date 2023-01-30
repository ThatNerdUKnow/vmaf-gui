import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { Col, Row } from "react-bootstrap";
import FileSelect from "./fileSelect";
import ResolutionSelect from "./resolutionSelect";
import PixelFormatSelect from "./pixelFormatSelect";

function VmafConfigForm() {
  return (
    <Form>
      <Row>
        <Col>
          <FileSelect type="Reference" />
        </Col>

        <Col>
          <FileSelect type="Distorted" />
        </Col>
      </Row>

      <ResolutionSelect/>

      <Row>
        <Col>
          <PixelFormatSelect/>
        </Col>
        <Col>
          <Form.Group className="mb-3">
            <Form.Label>Bit Depth</Form.Label>
            <Form.Select>
              <option>8</option>
              <option>10</option>
              <option>12</option>
            </Form.Select>
          </Form.Group>
        </Col>
      </Row>

      <Form.Group className="mb-3">
        <Form.Label>Model</Form.Label>
        <Form.Select>
          <optgroup label="Model">
            <option>vmaf_4k_v0.6.1</option>
            <option>vmaf_4k_v0.6.1neg</option>
            <option>vmaf_float_4k_v0.6.1</option>
            <option>vmaf_float_v0.6.1</option>
            <option>vmaf_float_v0.6.1neg</option>
            <option>vmaf_v0.6.1</option>
          </optgroup>
          <optgroup label = "Model Collection">
            <option>vmaf_b_v0.6.3</option>
            <option>vmaf_float_b_v0.6.3</option>
          </optgroup>
        </Form.Select>
      </Form.Group>

      <Button type="submit">Get VMAF Scores</Button>
    </Form>
  );
}

export default VmafConfigForm;
