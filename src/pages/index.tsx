import { useState } from "react";
import { invoke } from "@tauri-apps/api/tauri";
import Header from "../components/index/header";
import Form from "../components/index/form";
import { Container, Row,Col } from "react-bootstrap";

function App() {
  return (
    <Container className="m-4 mx-auto">
      <Row>
        <Col>
          <Header />
          <Form />
        </Col>
      </Row>
    </Container>
  );
}

export default App;
