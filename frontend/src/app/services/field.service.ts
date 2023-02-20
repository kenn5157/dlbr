import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Field } from '../field';

@Injectable({
  providedIn: 'root'
})
export class FieldService {

  private fieldUrl = 'https://localhost:5001/field'

  constructor(private http: HttpClient) { }

  private log(message: string) {
    // TODO: Create mesageService
    //this.messageService.add(`FieldService: ${message}`);
  }

  getFields(): Observable<Field[]> {
    return this.http.get<Field[]>(this.fieldUrl).pipe(
      tap(_ => this.log('fetched fields')),
      catchError(this.handleError<Field[]>('getFields', []))
    );
  }
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      this.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    }
  }
}
