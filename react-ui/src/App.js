import { Header } from "./layout/Header";
import { Footer } from "./layout/Footer";
import { Main } from "./layout/Main";
import {BrowserRouter} from 'react-router-dom'
// import '../node_modules/bootstrap/dist/css/bootstrap.min.css';

function App() {
  return (
    <>
    <BrowserRouter>
        <Header />
        <Main />
        <Footer />
    </BrowserRouter>
    </>
    );
}

export default App;
