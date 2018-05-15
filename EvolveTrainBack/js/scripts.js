// This script file handles on page interation as well as screen responsive interation


// function to handle toggle navigation 
(function () {

    let menuButton = document.getElementById("menu");
    let navMenu = document.getElementById("nav-menu");

    menuButton.addEventListener("click", toggleMenu);

    let toggle = false; // hidden at first
    function toggleMenu() {
        if (toggle) { // true: it's visible
            navMenu.classList.remove("show-menu"), // hide it
            toggle = false
        }
        else { // false: it's hidden
            navMenu.classList.add("show-menu"), // show it
            toggle = true
        }
    }

})();

// Quick Table Search
$('#search').keyup(function () {
    var regex = new RegExp($('#search').val(), "i");
    var rows = $('table tr:gt(0)');
    rows.each(function (index) {
        title = $(this).children("#title").html()
        if (title.search(regex) != -1) {
            $(this).show();
        } else {
            $(this).hide();
        }
    });
});
