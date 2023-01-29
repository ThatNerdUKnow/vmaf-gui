import logo from "../../assets/vmaf_logo.jpg";
import foo from "../../assets/vmaf_logo.jpg";
import { Row, Col } from "react-bootstrap";
function Header() {
  return (
    <Row className="align-items-center justify-content-center">
      <Col md={"auto"}>
        <img src={foo} />
      </Col>
      <Col>
        <h1>Vmaf Gui</h1>
        <p>Easily calculate vmaf scores</p>
      </Col>
    </Row>
  );
}

export default Header;
