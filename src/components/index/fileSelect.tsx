import Form from "react-bootstrap/Form";

export type FileSelectProps = {
  type: string;
};

function FileSelect(props: FileSelectProps) {
  return (
    <Form.Group>
      <Form.Label htmlFor={props.type}>{props.type}</Form.Label>
      <Form.Control
        id={props.type}
        type="file"
      />
    </Form.Group>
  );
}

export default FileSelect;
