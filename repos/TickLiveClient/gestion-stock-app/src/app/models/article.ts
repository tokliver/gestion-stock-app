

    export interface Article {
        id: number|undefined|null;
        nom: string;
        prixVenteUnitaire : number,
        prixVenteHT: number;
        prixVenteTTC: number;
        quantiteStock: number;
        articleType: string;
        tauxTVA: number;
        isVenteEmporter: boolean;
        stockId: number |undefined;
    }



