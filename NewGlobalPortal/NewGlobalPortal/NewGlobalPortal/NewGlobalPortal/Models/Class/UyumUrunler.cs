using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGlobalPortal.Models.Class
{


    public class UyumUrunler
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public UyumUrunlerResult[] result { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalCount { get; set; }
    }

    public class UyumUrunlerResult
    {
        public int id { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public string itemName2 { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
        public float qty { get; set; }
        public int mainItemId { get; set; }
        public string mainItemCode { get; set; }
        public string mainItemName { get; set; }
        public object[] itemAttributeList { get; set; }
        public string noteLarge { get; set; }
        public string noteLarge2 { get; set; }
        public int unitId { get; set; }
        public string unitCode { get; set; }
        public bool ispassive { get; set; }
        public int brandId { get; set; }
        public string brandCode { get; set; }
        public string brandDesc { get; set; }
        public int cccnId { get; set; }
        public string cccnCode { get; set; }
        public string cccnDesc { get; set; }
        public int catCode1Id { get; set; }
        public string catCode1 { get; set; }
        public string catDescription1 { get; set; }
        public int catCode2Id { get; set; }
        public string catCode2 { get; set; }
        public string catDescription2 { get; set; }
        public int defaultTaxId { get; set; }
        public string defaultTaxDesc { get; set; }
        public string defaultTaxRate { get; set; }
        public string defaultTaxCode { get; set; }
        public int categories10Id { get; set; }
        public int categories11Id { get; set; }
        public int categories12Id { get; set; }
        public int categories13Id { get; set; }
        public int categories14Id { get; set; }
        public int categories15Id { get; set; }
        public int categories16Id { get; set; }
        public int categories17Id { get; set; }
        public int categories18Id { get; set; }
        public int categories19Id { get; set; }
        public int categories1Id { get; set; }
        public int categories2Id { get; set; }
        public int categories3Id { get; set; }
        public int categories4Id { get; set; }
        public int categories5Id { get; set; }
        public int categories6Id { get; set; }
        public int categories7Id { get; set; }
        public int categories8Id { get; set; }
        public int categories9Id { get; set; }
        public string categories10Code { get; set; }
        public string categories11Code { get; set; }
        public string categories12Code { get; set; }
        public string categories13Code { get; set; }
        public string categories14Code { get; set; }
        public string categories15Code { get; set; }
        public string categories16Code { get; set; }
        public string categories17Code { get; set; }
        public string categories18Code { get; set; }
        public string categories19Code { get; set; }
        public string categories1Code { get; set; }
        public string categories2Code { get; set; }
        public string categories3Code { get; set; }
        public string categories4Code { get; set; }
        public string categories5Code { get; set; }
        public string categories6Code { get; set; }
        public string categories7Code { get; set; }
        public string categories8Code { get; set; }
        public string categories9Code { get; set; }
        public string categories10Desc { get; set; }
        public string categories11Desc { get; set; }
        public string categories12Desc { get; set; }
        public string categories13Desc { get; set; }
        public string categories14Desc { get; set; }
        public string categories15Desc { get; set; }
        public string categories16Desc { get; set; }
        public string categories17Desc { get; set; }
        public string categories18Desc { get; set; }
        public string categories19Desc { get; set; }
        public string categories1Desc { get; set; }
        public string categories2Desc { get; set; }
        public string categories3Desc { get; set; }
        public string categories4Desc { get; set; }
        public string categories5Desc { get; set; }
        public string categories6Desc { get; set; }
        public string categories7Desc { get; set; }
        public string categories8Desc { get; set; }
        public string categories9Desc { get; set; }
        public string addString01 { get; set; }
        public string addString02 { get; set; }
        public string addString03 { get; set; }
        public string addString04 { get; set; }
        public string addString05 { get; set; }
        public string addString06 { get; set; }
        public string addString07 { get; set; }
        public string addString08 { get; set; }
        public string addString09 { get; set; }
        public string addString10 { get; set; }
        public DateTime addDate01 { get; set; }
        public DateTime addDate02 { get; set; }
        public DateTime addDate03 { get; set; }
        public DateTime addDate04 { get; set; }
        public DateTime addDate05 { get; set; }
        public DateTime addDate06 { get; set; }
        public DateTime addDate07 { get; set; }
        public DateTime addDate08 { get; set; }
        public DateTime addDate09 { get; set; }
        public DateTime addDate10 { get; set; }
        public float addDec01 { get; set; }
        public float addDec02 { get; set; }
        public float addDec03 { get; set; }
        public float addDec04 { get; set; }
        public float addDec05 { get; set; }
        public float addDec06 { get; set; }
        public float addDec07 { get; set; }
        public float addDec08 { get; set; }
        public float addDec09 { get; set; }
        public float addDec10 { get; set; }
        public object itemEditor { get; set; }
        public Itempricelist[] itemPriceList { get; set; }
        public object[] itemBarcodeList { get; set; }
        public Itemlanglist[] itemLangList { get; set; }
        public Bwhitemlist[] bwhItemList { get; set; }
        public Bwhitemdlist[] bwhItemDList { get; set; }
        public object[] itemImageList { get; set; }
    }

    public class Itempricelist
    {
        public int id { get; set; }
        public object barcode { get; set; }
        public int itemId { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool ispassive { get; set; }
        public int priceListId { get; set; }
        public int priceListMId { get; set; }
        public string priceListCode { get; set; }
        public string priceListDesc { get; set; }
        public float rate { get; set; }
        public int unitId { get; set; }
        public string unitCode { get; set; }
        public float unitPriceTra { get; set; }
        public string vatStatus { get; set; }
        public float disc1Rate { get; set; }
        public float disc2Rate { get; set; }
        public float disc3Rate { get; set; }
        public string discCode1 { get; set; }
        public string discCode2 { get; set; }
        public string discCode3 { get; set; }
        public string purchaseSales { get; set; }
        public int itemAttribute1Id { get; set; }
        public string itemAttribute1Code { get; set; }
        public int itemAttribute2Id { get; set; }
        public string itemAttribute2Code { get; set; }
        public int itemAttribute3Id { get; set; }
        public string itemAttribute3Code { get; set; }
        public int entityId { get; set; }
        public string entityPriceGrpCode { get; set; }
        public string entityPriceGrpName { get; set; }
        public string note1 { get; set; }
        public string note2 { get; set; }
        public int curId { get; set; }
        public string curCode { get; set; }
        public float sonFiyat { get; set; }
    }

    public class Itemlanglist
    {
        public int id { get; set; }
        public int itemId { get; set; }
        public string itemName { get; set; }
        public string itemName2 { get; set; }
        public string description { get; set; }
        public int langId { get; set; }
        public string langCode { get; set; }
    }

    public class Bwhitemlist
    {
        public int id { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
        public int itemId { get; set; }
        public string itemCode { get; set; }
        public int branchId { get; set; }
        public string branchCode { get; set; }
        public int whouseId { get; set; }
        public string whouseCode { get; set; }
        public float qtyAfterSalesPurchase { get; set; }
        public float toleranceRateByItem { get; set; }
        public float qtyMaxInv { get; set; }
        public float qtyMaxPo { get; set; }
        public float qtyMaxSo { get; set; }
        public float qtyMinInv { get; set; }
        public float qtyMinPo { get; set; }
        public float qtyMinSo { get; set; }
        public float qtyPo { get; set; }
        public float qtyPrm { get; set; }
        public float qtySo { get; set; }
        public float qtyFreePrm { get; set; }
        public float qtyFreeSec { get; set; }
        public float toleranceMaxPo { get; set; }
        public float toleranceMinPo { get; set; }
        public float toleranceMinSo { get; set; }
        public float netWeight { get; set; }
        public int abtBudgetId { get; set; }
        public string abtBudgetCode { get; set; }
        public string abtBudgetDesc { get; set; }
        public bool isnegative { get; set; }
        public bool ispassive { get; set; }
        public string itemAccIntgCode { get; set; }
    }

    public class Bwhitemdlist
    {
        public int id { get; set; }
        public int itemId { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
        public int branchId { get; set; }
        public int whouseId { get; set; }
        public string whouseCode { get; set; }
        public int lotId { get; set; }
        public string lotCode { get; set; }
        public int qualityId { get; set; }
        public string qualityCode { get; set; }
        public int colorId { get; set; }
        public string colorCode { get; set; }
        public int itemAttribute1Id { get; set; }
        public int itemAttribute2Id { get; set; }
        public int itemAttribute3Id { get; set; }
        public string itemAttributeCode1 { get; set; }
        public string itemAttributeCode2 { get; set; }
        public string itemAttributeCode3 { get; set; }
        public int bomMId { get; set; }
        public string bomMDesc { get; set; }
        public int packageTypeId { get; set; }
        public string packageTypeCode { get; set; }
        public float qtyPrm { get; set; }
        public Pricelistdatt[] priceListDAtt { get; set; }
        public object[] itemBarcodeList { get; set; }
    }

    public class Pricelistdatt
    {
        public int id { get; set; }
        public object barcode { get; set; }
        public int itemId { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool ispassive { get; set; }
        public int priceListId { get; set; }
        public int priceListMId { get; set; }
        public string priceListCode { get; set; }
        public string priceListDesc { get; set; }
        public float rate { get; set; }
        public int unitId { get; set; }
        public string unitCode { get; set; }
        public float unitPriceTra { get; set; }
        public string vatStatus { get; set; }
        public float disc1Rate { get; set; }
        public float disc2Rate { get; set; }
        public float disc3Rate { get; set; }
        public string discCode1 { get; set; }
        public string discCode2 { get; set; }
        public string discCode3 { get; set; }
        public string purchaseSales { get; set; }
        public int itemAttribute1Id { get; set; }
        public string itemAttribute1Code { get; set; }
        public int itemAttribute2Id { get; set; }
        public string itemAttribute2Code { get; set; }
        public int itemAttribute3Id { get; set; }
        public string itemAttribute3Code { get; set; }
        public int entityId { get; set; }
        public string entityPriceGrpCode { get; set; }
        public string entityPriceGrpName { get; set; }
        public string note1 { get; set; }
        public string note2 { get; set; }
        public int curId { get; set; }
        public string curCode { get; set; }
    }




    public class ImageResult
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public ImageResultDetail[] result { get; set; }
    }

    public class ImageResultDetail
    {
        public int itemId { get; set; }
        public string image { get; set; }
    }

}