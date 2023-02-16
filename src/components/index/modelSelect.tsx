import { useAtom } from "jotai";
import { Form } from "react-bootstrap";
import { modelAtom } from "../../atoms/model";
import { BuiltinModels } from "../../atoms/model";
import { ChangeEvent } from "react";


export default function ModelSelect() {
  let [selectedModel, setSelectedModel] = useAtom(modelAtom);

  function handleChange(event:ChangeEvent<HTMLSelectElement>){
    setSelectedModel(event.target.value)
  }
  return (
    <Form.Group>
      <Form.Label>Model</Form.Label>
      <Form.Select value={selectedModel} onChange={handleChange}>
          {BuiltinModels.map((model, index) => (
            <option key={index} value={model}>
              {model}
            </option>
          ))}
      </Form.Select>
    </Form.Group>
  );
}
