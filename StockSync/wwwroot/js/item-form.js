document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('Img').addEventListener('change', function () {
        const file = this.files[0];
        const previewElement = document.querySelector('.img-preview');
        const imageUrl = window.URL.createObjectURL(file);

        if (previewElement) {
            previewElement.src = imageUrl;
            previewElement.style.display = "block";
        }
    });
});
