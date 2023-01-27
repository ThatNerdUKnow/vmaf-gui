import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/esm/Button';

function VmafConfigForm() {
  return (
    <Form>

      <Form.Group className="mb-3">
          <Form.Label htmlFor="reference">
            Reference
          </Form.Label>
          <Form.Control
            id="reference"
            type="file"
            className="file-input file-input-bordered w-full max-w-xs"
          />
      </Form.Group>

      <Form.Group className="mb-3">
          <Form.Label htmlFor="distorted">
            Distorted
          </Form.Label>
          <Form.Control
            id="distorted"
            type="file"
            className="file-input file-input-bordered w-full max-w-xs"
          />
      </Form.Group>

      <Form.Group className='mb-3'>
        <Form.Label>Resolution</Form.Label>
        <Form.Select>
            <option>3840x2160</option>
            <option>2560x1440</option>
            <option>1920x1080</option>
            <option>1280x720</option>
            <option>custom</option>
        </Form.Select>
      </Form.Group>

      <Form.Group className='mb-3'>
        <Form.Label>Model</Form.Label>
        <Form.Select>
            <option>vmaf_4k_v0.6.1</option>
            <option>vmaf_4k_v0.6.1neg</option>
            <option>vmaf_float_4k_v0.6.1</option>
            <option>vmaf_float_v0.6.1</option>
            <option>vmaf_float_v0.6.1neg</option>
            <option>vmaf_v0.6.1</option>
        </Form.Select>
      </Form.Group>

      <div className="divider"></div>
      <Button type="submit">Get VMAF Scores</Button>
    </Form>
  );
}

export default VmafConfigForm;
