import { useState, useEffect } from "react";
import axios from "axios";
import Cabecalho from "../../components/cabecalho/cabecalho"
import Rodape from "../../components/rodape/rodape"
import SituacaoConsulta from "../../components/situacaoConsulta/situacaoConsulta";
// import SetaCima from "../../components/icones/setaCima";
import SetaBaixo from "../../components/icones/setaBaixo";

import "../../assets/css/consultas.css"

export default function ConsultasPaciente() {
    const [listaConsultas, setListaConsultas] = useState([]);


    function buscarMinhasConsultas() {
        axios("http://localhost:5000/api/Consultas/Minhas", {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaConsultas(resposta.data);
                    // console.log(resposta.data)
                    // console.log(listaConsultas)
                }
            }).catch(erro => console.log(erro));
    }

    useEffect(buscarMinhasConsultas, []);

    function abrirDescricao(idConsulta){
        //mesma coisa pra desalterar select, porém com a descrição display none ou não
        var textoDescricao = document.getElementById("texto_desc"+ idConsulta);
        if (textoDescricao.value === null || textoDescricao.value === "" || textoDescricao.value === undefined) {
            textoDescricao.value = "Consulta sem descrição";
        }

        if (textoDescricao.style.display === "none") {
            textoDescricao.style.display = "";
        } else{
            textoDescricao.style.display = "none";
        }
    }



    return (

        <div>
            <Cabecalho />
            <main>

            <div class="container container_banner">
     <h1>Lista de consultas</h1>
 </div>
 <section class=" container listagem">
     <h2>Listagem de consultas</h2>

                    {
                        listaConsultas.map((consulta) => {
                            // console.log(consulta.idSituacaoNavigation.situacao1)
                            return (
                                <div key={consulta.idConsulta} className=" consulta">
                                    <div className="informacoes_principais">
                                        <div className="info_users">
                                            <div className="info">
                                                <p className="chave">Paciente:</p>
                                                <p className="valor">{consulta.idClienteNavigation.nomeCliente}</p>
                                            </div>

                                            <div className="info">
    <p className="chave">Data da Consulta:</p>
    <p className="valor">{Intl.DateTimeFormat("pt-BR", {
        year: "numeric", month: "long", day: "numeric", hour: "numeric", minute: "numeric"
    }).format(new Date(consulta.dataConsulta))}</p>
</div>

                                            <div className="info">
                                                <p className="chave">Medico:</p>
                                                <p className="valor">{consulta.idMedicoNavigation.nomeMedico}</p>
                                            </div>
                                            <div className="info">
                                                <p className="chave">Especialidade:</p>
                                                <p className="valor">{consulta.idMedicoNavigation.idEspecialidadeMedicoNavigation.nomeEspecialidade}</p>
                                            </div>
                                        </div>
                                        <div className="info_consulta">
                                            <div className="situacao">
                                                <div className=" info chave ">
                                                    <SituacaoConsulta situacao={consulta.idSituacaoNavigation.situacao1} />
                                                    <button type="button" className="vazio"><i className="far fa-edit"></i></button>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div className="informacoes_secundarias">
                                        <p className="chave">Descricao da consulta</p>
                                        <button onClick={() =>abrirDescricao(consulta.idConsulta)} type="button" className="vazio"><SetaBaixo /></button>                                    </div>
                                    <div className="descricao">
                                        <textarea name="texto_desc" id={"texto_desc" + consulta.idConsulta} className="valor vazio" style={{ resize: "none", display: "none" }}
                                            cols="76" rows="3" readOnly>{consulta.descricaoConsulta}</textarea>
                                    </div>
                                </div>

                            )

                        })
                    }


                </section>

            </main>

            <Rodape />


        </div>
    )
}