import { useEffect, useState } from "react";
import { open } from "@tauri-apps/api/dialog";
import {
  videoDir as GetVideoDir,
  extname,
  basename,
} from "@tauri-apps/api/path";
import Form from "react-bootstrap/Form";
import { Button, InputGroup } from "react-bootstrap";

export type FileSelectProps = {
  type: string;
};

function FileSelect(props: FileSelectProps) {
  const [file,setFile] = useState("")
  const [fullPath, setFullPath] = useState("");
  const [isInvalid, setIsInvalid] = useState(false);

  useEffect(() => {
    async function calculateFileName() {
      setFile(await basename(fullPath));
    }
    if (fullPath) {
      calculateFileName();
    }
  }, [fullPath]);

  async function handleClick(event) {
    event.preventDefault();

    const videoDir = await GetVideoDir();

    const selected = await open({
      multiple: false,
      defaultPath: videoDir,
      title: `Select ${props.type} video`,
    });

    if (typeof selected === "string") {
      setFullPath(selected);
    }
  }

  return (
    <>
      <Form.Group>
        <Form.Label htmlFor={props.type}>{props.type}</Form.Label>
        <InputGroup className="is-invalid" onClick={handleClick}>
          <Button>Select File:</Button>
          {/* This is a dummy form control that only displays the "file" part of the path */}
          <Form.Control type="text" value={file} readOnly />
        </InputGroup>
      </Form.Group>
      {/* This is a hidden form control which actually holds the value we want */}
      <Form.Control
        name={props.type}
        type="text"
        value={fullPath}
        readOnly
        style={{ display: "none" }}
      />
    </>
  );
}

export default FileSelect;
