import { Injectable } from '@angular/core';
import axios from 'axios';

export const customAzios = axios.create({
  baseURL: 'https://localhost:5001'
})
@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

  async getProducts(){
    const httpRespone = await customAzios.get<any>('field');
    return httpRespone.data;
  }

  async createProduct(dto: { animalGroupId: number; fieldName: string; fieldSize: number; animalCount: number; lastChange: Date; cropType: string; status: string }) {
    return await customAzios.post('field', dto);
    console.log(dto)
  }
}
