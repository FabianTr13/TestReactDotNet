import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import RequisicionView from "./Views/RequisicionView/RequisicionView";
import MovimientosView from "./Views/MovimientosView/MovimientosView";
import NavBar from "./Components/NavBar";
import RevertDocumentView from "./Views/RevertDocument/RevertDocumentView";

function App() {
  return (
    <div>
      <Router>
        <NavBar />
        <Switch>
          <Route exact path="/">
            <RequisicionView />
          </Route>
          <Route exact path="/movimientos">
            <MovimientosView />
          </Route>
          <Route exact path="/revert">
            <RevertDocumentView />
          </Route>
        </Switch>
      </Router>
    </div>
  );
}

export default App;
