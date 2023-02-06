// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


document.querySelector('.create-new-task').addEventListener('click', function () {
    document.querySelector('.js-add-task').classList.remove("js-add-task");
})

document.querySelector('.cancel').addEventListener('click', function () {
    document.querySelector('.js-cancel').classList.add("js-add-task");
})