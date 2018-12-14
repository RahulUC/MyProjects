// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
// JAVASCRIPT CODE WILL GO HERE

// WHEN DOCUMENT READY
var app = new Vue({
    el: "#app",
    data: {
        // PLACE DATA PROPERTIES HERE - THIS IS THE "MODEL" FOR OUR PROGRAM
        items: [],
        form: {
            product: "",
            price: ""
        }
    },
    mounted: function () {
        // PERFORM ANY ACTIONS WHEN THE PAGE LOADS HERE - SIMILAR TO JQUERY DOCUMENT.READY
        this.loadData();
    },
    methods: {
        // ADD ANY METHODS (CLICK, SUBMIT EVENTS, ETC.)
        loadData: function () {
            var self = this;
            $.ajax({
                url: "/api/groceries",
                dataType: 'json',
                contentType: 'application/json',
                method: 'GET'
            }).done(function (responseJSON, status, xhr) {
                self.items = responseJSON;
            }).fail(function (xhr, status, error) {
                // deal with error from server (status code 400-599)
                alert("There was an error retrieving the data");
            });
        },
        addItem: function () {
            var self = this;
            $.ajax({
                url: '/api/groceries',
                dataType: 'json',
                contentType: 'application/json',
                method: 'POST',
                data: JSON.stringify(self.form)
            }).done(function (responseData, status, xhr) {
                self.loadData(); // RELOAD THE ITEMS DATA
                $('#createPrdForm').css("display", "none");
                alert("Item added successfully");
                self.form.product = "";
                self.form.price = "";
            }).fail(function (xhr, status, error) {
                alert("There was an error saving your grocery item");
            });
        },
        deleteItem: function (item) {
            var self = this;
            $.ajax({
                url: '/api/groceries/' + item.id,
                dataType: 'json',
                contentType: 'application/json',
                method: 'DELETE'
            }).done(function (responseData, status, xhr) {
                self.loadData();
                alert("Item deleted successfully");
            }).fail(function (xhr, status, error) {
                alert("There was an error deleting your grocery item");
            });
        },
        updateItem: function (item) {
            var self = this;
            $.ajax({
                url: '/api/groceries/sell/' + item.id,
                dataType: 'json',
                contentType: 'application/json',
                method: 'PUT',
                data: JSON.stringify(item)
            }).done(function (responseData, status, xhr) {
                self.loadData();
            }).fail(function (xhr, status, error) {
                alert("There was an error updating your grocery item");
            });
        }

    },
    computed: {
        // CREATE ANY CALCULATED PROPERTIES HERE. THEY BEHAVE LIKE READ-ONLY DATA
    }
});