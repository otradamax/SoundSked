import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ListImage } from "./listImage.model";

const listUrl = "/api/list";

@Injectable()
export class Repository{
    listImages: ListImage[];

    constructor(private http: HttpClient){
        this.getListImages();
    }

    getListImages(){
        this.http.get<ListImage[]>(listUrl).subscribe(listImg => this.listImages = listImg);
    }
}