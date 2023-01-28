import { useState } from "react";
import { open } from "@tauri-apps/api/dialog";

import Form from "react-bootstrap/Form";
import { Button, InputGroup, Row } from "react-bootstrap";

export type FileSelectProps = {
  type: string;
};

function FileSelect(props: FileSelectProps) {
  let [file, setFile] = useState("");
  let [isInvalid, setIsInvalid] = useState(false);

  async function handleClick(event) {
    event.preventDefault();
    console.log("Clicked");
    const selected = await open({
      multiple: false,
      title: `Select ${props.type} video`
    });

    if(typeof selected === 'string'){
      setFile(selected)
    }
  }

  return (
    <Form.Group>
      <Form.Label htmlFor={props.type}>{props.type}</Form.Label>
      <InputGroup className="is-invalid" onClick={handleClick}>
        <Button>Select File:</Button>
        <Form.Control type="text" value={file} readOnly />
      </InputGroup>
    </Form.Group>
  );
}

export default FileSelect;
