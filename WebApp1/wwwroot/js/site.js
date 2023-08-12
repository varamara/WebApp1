function footerPosition(element, scrollHeight, innerHeight) {
    try {
        const _element = document.querySelector(element)
        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight)

        _element.classList.toggle('position-fixed-bottom', !isTallerThanScreen)
        _element.classList.toggle('position-static', isTallerThanScreen)
    } catch { }
}
footerPosition('footer', document.body.scrollHeight, window.innerHeight)


function toggleMenu(attribute) {
    try {
        const toggleBtn = document.querySelector(attribute)
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'))

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu')
                toggleBtn.classList.add('btn-outline-dark')
                toggleBtn.classList.add('btn-toggle-white')
            }

            else {
                element.classList.remove('open-menu')
                toggleBtn.classList.remove('btn-outline-dark')
                toggleBtn.classList.remove('btn-toggle-white')
            }
        })
    } catch { }
}
toggleMenu('[data-option="toggle"]')


function createDropdown() {
    const dropdownToggle = document.getElementById('account-dropdown');
    const dropdownMenu = document.querySelector('.dropdown-menu');

    dropdownToggle.addEventListener('click', function () {
        dropdownMenu.classList.toggle('show');
    });
}


document.querySelector("#description").classList.add("active");

function openTab(evt, tabName) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].classList.remove("active");
    }
    document.getElementById(tabName).style.display = "block";
    evt.currentTarget.classList.add("active");
}

document.querySelector(".tablinks.active").click();


try {

    const toggleButton = document.querySelector('[data-option="toggle"]')
    const target = toggleButton.getAttribute('data-target')
    toggleButton.addEventListener('click', toggleTarget)

    function toggleTarget() {
        console.log('test')

        const element = document.querySelector(target)

        if (!element.classList.contains('hide')) {
            element.classList.add('hide')
        } else {
            element.classList.remove('hide')
        }
    }
} catch { }




