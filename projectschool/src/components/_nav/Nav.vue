<template>
    <div class="barraTop">
        <nav class="marginPrincipal">
            <router-link to="/professores">Professores</router-link>
            <router-link to="/alunosall">Alunos</router-link>
            <router-link to="/sobre">Sobre</router-link>
        </nav>
    </div>
</template>

<script>
    export default {
        
    }
</script>

<style scoped>
    .barraTop{
        background-color: rgb(230,230,230);
    } 


    nav {
        padding: 20px 20px 20px 0px;
    }

        nav a {
            margin-right: 15px;
            padding: 10px;
            text-decoration: none;
            background-color: #fff;
            border-radius: 3px;
            color: rgb(0, 110, 255);
            font-weight: bold;

        }

        nav .router-link-active {
            background-color: rgb(160, 160, 160);
            color: white;
        }
</style>