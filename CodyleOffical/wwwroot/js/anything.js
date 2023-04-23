const box = document.getElementById('box');

const btn = document.getElementById('btn');

btn.addEventListener('click', function handleClick() {
  if (box.style.visibility === 'hidden') {
    box.style.visibility = 'visible';

    btn.textContent = 'Hide div';
  } else {
    box.style.visibility = 'hidden';

    btn.textContent = 'Show div';
  }
});