// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const windowOpen = document.querySelectorAll(".window-open");

windowOpen.forEach(item => {
    item.addEventListener('click', function () {
        document.querySelector("body").classList.add("background-black")
        document.querySelector(".window").classList.remove("window-remove");
    })
})


document.querySelector(".window").addEventListener('click', function () {
    document.querySelector(".window").classList.add("window-remove");
    document.querySelector("body").classList.remove("background-black")
})