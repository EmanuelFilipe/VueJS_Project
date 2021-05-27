<template>
    <div>
        <div class="divTitulo">
            <h1>{{texto}}</h1>
            <div class="voltar">
                <!-- slot - permite incluir outros elementos dentro do espaço daquele componente -->
                <slot></slot>
                <button v-show="btnVoltar" class="btn btnVoltar" @click="voltar()">Voltar</button>
            </div>

        </div>
    </div>
</template>

<script>
    export default {
        props: {
            texto: String,
            btnVoltar: Boolean
        },
        methods: {
            voltar(){
                this.$router.back();
            }
        }
    }
</script>

<style scoped>
    .divTitulo {
        display: flex;
        width: 50%;
    }
    .voltar{
        width: 50%;
        position: absolute;
        margin-top: 15px;
    }

    .btnVoltar{
        float: right;
        background-color: rgb(199,199,199);
    }
</style>