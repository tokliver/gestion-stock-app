export interface ArticleQueryFilter {
    id: number|undefined|null;
    nom: string;
    prixVenteUnitaireMin : number|undefined|null;
    prixVenteUnitaireMax : number|undefined|null;
}