import Image from "next/image";
import logo from "../../assets/vmaf_logo.jpg";
import { Row, Col } from "react-bootstrap";
function Header() {
  return (
    <Row className="align-items-center justify-content-center">
      <Col md={"auto"}>
        <Image src={logo} alt={"Logo for the VMAF project by Netflix"} />
      </Col>
      <Col>
        <h1>Vmaf Gui</h1>
        <p>Easily calculate vmaf scores</p>
      </Col>
    </Row>
  );
}

export default Header;
