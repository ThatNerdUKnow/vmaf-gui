import { useState } from "react";
import { invoke } from "@tauri-apps/api/tauri";
import Header from "../components/index/header";
import Form from "../components/index/form";

function App() {
  return (
    <div className="container prose m-5">
      <Header />
      <div className="divider" />
      <Form />
    </div>
  );
}

export default App;
