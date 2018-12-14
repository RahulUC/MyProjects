// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
// JAVASCRIPT CODE WILL GO HERE

// WHEN DOCUMENT READY
new Vue({
    el: '#app',
    data() {
        return {
            info: null,
            loading: true,
            errored: false
        }
    },
    filters: {
        currencydecimal(value) {
            return value.toFixed(2)
        }
    },
    mounted() {
        axios
            .get('https://api.coindesk.com/v1/bpi/currentprice.json')
            .then(response => {
                this.info = response.data.bpi
            })
            .catch(error => {
                console.log(error)
                this.errored = true
            })
            .finally(() => this.loading = false)
    }
})