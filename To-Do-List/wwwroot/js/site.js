const windowOpen = document.querySelectorAll(".window-open");
const windowRemove = document.querySelectorAll(".window-remove");
const windowClose = document.querySelectorAll(".window")
const body = document.querySelector("body");

windowOpen.forEach((item, index) => {
    item.addEventListener('click', function () {
        windowRemove[index].classList.remove("window-remove")
        body.classList.add("background-black");
    })
})

windowClose.forEach(item => {
    item.addEventListener('click', function () {
        item.classList.add("window-remove");
        body.classList.remove("background-black")
    })
})