﻿Function ChangeImage(UploadImage, previewImg){
    if (UploadImage.files && UploadImage.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImg).attr('src', e.target.result);

        }
        reader.readAsDataURL(UpLoadImage.files[0]));
        }
    }
}