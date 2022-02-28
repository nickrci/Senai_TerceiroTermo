import React from 'react'
import { Link } from 'react-router-dom';
import Analise from '../Logado/logado';


export default function Cabecalho() {
    return (
        <header>
        <div class="sp">
            <a href="/">SpMedical</a>
        </div>
        <div class="menu">
            <a href="#home">Home</a>
            <a href="#sobre_nos">Sobre nós</a>
            <a href="#Especialidades">Especialidades</a>
        <Analise />
        </div>
    </header>
    )
}
