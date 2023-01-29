import { MouseEventHandler, useEffect, useState } from "react";
import { open } from "@tauri-apps/api/dialog";
import Form from "react-bootstrap/Form";
import { basename, videoDir as GetVideoDir } from "@tauri-apps/api/path";
import { Button, InputGroup } from "react-bootstrap";
import { invoke } from "@tauri-apps/api";

export type FileSelectProps = {
  type: string;
};

function FileSelect(props: FileSelectProps) {
  const [file, setFile] = useState("");
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

  useEffect(() => {
    async function validateVideo() {
      try {
        await invoke("validate_video", { path: fullPath });
        setIsInvalid(false);
      } catch (e) {
        console.error(e);
        setIsInvalid(true);
      }
    }
    if (fullPath !== "") {
      validateVideo();
    }
  }, [fullPath]);

  async function handleClick() {
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
          <Form.Control
            className={isInvalid ? "is-invalid" : ""}
            type="text"
            value={file}
            readOnly
          />
          {isInvalid ? (
            <div className="invalid-feedback">This file is not a video!</div>
          ) : null}
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
