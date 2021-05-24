<template>
    <div>
        <h1>{{texto}}</h1>
    </div>
</template>

<script>
    export default {
        // criando variavel para receber como parâmetro
        props:{
            texto: String
        }
    }
</script>

<style scoped>

</style>