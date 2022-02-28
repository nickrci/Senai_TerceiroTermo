import { Component } from "react";
import axios from "axios";
import { Link } from 'react-router-dom';
import logo from '../../assets/img/LogoSimples.png'

import { parseJWT, usuarioAutenticado } from "../../services/auth";

import "../../assets/css/estiloLogin.css"

export default class Login extends Component{
    constructor(props){
        super(props);
        this.state={
            email: "",
            senha: "",
            erroMensagem: "",
            isLoading: false
        }
    };

    EfetuaLogin = (evento) => {
        evento.preventDefault();

        this.setState({ erroMensagem: '', isLoading: true });

        axios.post("http://localhost:5000/api/Login", {
            email: this.state.email,
            senha: this.state.senha
        })

        .then(resposta => {
            if (resposta.status === 200) {
                // console.log("token: " + resposta.data.token);

                localStorage.setItem("usuario-login", resposta.data.token);

                this.setState({ isLoading: false});

                // let base64 = localStorage.getItem("usuario-login").split(".")[1];

                // console.log("base64: " + base64);

                // console.log(this.props);

                switch (parseJWT().role) {
                    case "1":
                        this.props.history.push("/consultasAdm")
                        console.log("estou logado: " + usuarioAutenticado())
                        break;

                    case "2":
                        this.props.history.push("/consultasMedico")
                        console.log("estou logado: " + usuarioAutenticado())
                        break;

                    case "3":
                        this.props.history.push("/consultasPaciente")
                        console.log("estou logado: " + usuarioAutenticado())
                        break;
                
                    default:
                        this.props.history.push("/")
                        break;
                }
            }
        }).catch( erro => console.log(erro), this.setState({ erroMensagem: "credenciais inválidas"}))

    }

    AtualizaStateCampo = (campo) =>{
        this.setState({[campo.target.name]: campo.target.value })
    }

    render(){


        return (
            <div>

                <main>

                <section class="container-login flex">
  <div class="img__login"></div>
  <div class="item__login">
    <div class="row">
      <div class="item">
      <Link to="/"><img src={logo} className="icone__login" alt="logoSP" /> </Link>
      </div>
      <div class="item" id="item__title">
        <p class="text__login" id="item__description">
          Acesse sua conta!!!
        </p>
      </div>
      <form>
        <div class="item">
          <input
            class="input__login"
            placeholder="username"
            type="text"
            name="username"
            id="login__email"
          />
        </div>
        <div class="item">
          <input
            class="input__login"
            placeholder="password"
            type="password"
            name="password"
            id="login__password"
          />
        </div>
        <div class="item">
          <button class="btn btn__login" id="btn__login">
            Login
          </button>
        </div>
      </form>
    </div>
  </div>
</section>


                </main>

            </div>
        )


        
    }
}