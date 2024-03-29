﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewGlobalPortal.Models.Class
{
    

    public class UyumSiparisler
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public UyumSiparislerResult result { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public int totalCount { get; set; }
    }

    public class UyumSiparislerResult
    {
        public Order_M[] ordeR_M { get; set; }
        public Order_D[] ordeR_D { get; set; }
        public object[] ordeR_D2 { get; set; }
        public object[] ordeR_D_TAX { get; set; }
    }

    public class Order_M
    {
        //public string isNotControlFreeQty { get; set; }
        //public string id { get; set; }
        //public string isHasFile { get; set; }
        //public string deliveryDate { get; set; }
        //public string entityOrderDate { get; set; }
        //public string entityRequestDate { get; set; }
        //public string entityOrderNo { get; set; }
        public string orderStatus { get; set; }
        //public string advisingBankId { get; set; }
        //public string advisingBankRef { get; set; }
        //public string issuingBankId { get; set; }
        //public string issuingBankRef { get; set; }
        //public string adBankAccNo { get; set; }
        //public string isBankAccNo { get; set; }
        //public string adBankAccDesc { get; set; }
        //public string isBankAccDesc { get; set; }
        //public string requestStatus { get; set; }
        //public string autoOrderType { get; set; }
        //public string exporterId { get; set; }
        //public string brokerId { get; set; }
        //public string sourceGuid { get; set; }
        //public string countryOfOriginId { get; set; }
        //public string countryOfOutId { get; set; }
        //public string transportType { get; set; }
        //public string incotermsId { get; set; }
        //public string incotermsName { get; set; }
        //public string paymentMethodId { get; set; }
        //public string approvalStatusId { get; set; }
        //public string approvalStatusCode { get; set; }
        //public string paymentMethodType { get; set; }
        //public string isApproveByMaster { get; set; }
        //public string referralOrderStatus { get; set; }
        //public string isSalesPackageLot { get; set; }
        //public string groupBranchId { get; set; }
        //public string groupBranchCode { get; set; }
        //public string groupBranchName { get; set; }
        //public string isLocalCurAction { get; set; }
        //public string currencyOption { get; set; }
        //public string coId { get; set; }
        //public string entityId { get; set; }
        //public string entityLatitude { get; set; }
        //public string entityLongitude { get; set; }
        //public string addString01 { get; set; }
        //public string addString02 { get; set; }
        //public string identifyNo { get; set; }
        //public string curTraId { get; set; }
        //public string latitude { get; set; }
        //public string longitude { get; set; }
        //public string loadingCardId { get; set; }
        //public object loadingCardCode { get; set; }
        //public object loadingCardDesc { get; set; }
        //public string isTransitOrder { get; set; }
        //public string transitOrderMId { get; set; }
        //public string orderMonth { get; set; }
        //public string configSourceType { get; set; }
        //public string distributeExpensePrice { get; set; }
        //public string entityContact { get; set; }
        //public string entityTel1 { get; set; }
        //public string entityTel2 { get; set; }
        //public string entityMail { get; set; }
        //public string whouseAddressDId { get; set; }
        //public string whAddressTypeCode { get; set; }
        //public string whCityName { get; set; }
        //public string whTownName { get; set; }
        //public string whCountryName { get; set; }
        //public string whAddress1 { get; set; }
        //public string whAddress2 { get; set; }
        //public string whAddress3 { get; set; }
        //public string cargoKey { get; set; }
        //public string invoiceType { get; set; }
        //public string coDesc { get; set; }
        //public string catDesc1 { get; set; }
        //public string catDesc2 { get; set; }
        //public string countryCode { get; set; }
        //public string curRateTypeDesc { get; set; }
        //public string curTraDesc { get; set; }
        //public string paymentPlanDesc { get; set; }
        //public string dicsDesc0 { get; set; }
        //public string discDesc1 { get; set; }
        //public string discDesc2 { get; set; }
        //public string discDesc3 { get; set; }
        //public string exporterCode { get; set; }
        //public string exporterName { get; set; }
        //public string brokerCode { get; set; }
        //public string brokerName { get; set; }
        //public string shippingCountryCode { get; set; }
        //public string countryOfOutCode { get; set; }
        //public string countryOfOutName { get; set; }
        //public string incotermsCode { get; set; }
        //public string incotermsDesc { get; set; }
        public string paymentMethodCode { get; set; }
        //public string paymentMethodDesc { get; set; }
        //public string countryOfOriginCode { get; set; }
        //public string countryOfOriginName { get; set; }
        public string purchaseSales { get; set; }
        //public string orderUpdatePlace { get; set; }
        //public string offerProcess { get; set; }
        //public string paymentMethodBankId { get; set; }
        //public string isReferralOrders { get; set; }
        //public string parentEntityCode { get; set; }
        //public string entityGrpCode1 { get; set; }
        //public string entityGrpName1 { get; set; }
        //public string entityGrpCode2 { get; set; }
        //public string entityGrpName2 { get; set; }
        //public string entityGrpCode3 { get; set; }
        //public string shortCardName { get; set; }
        //public string entityNote { get; set; }
        //public string entityGrpName3 { get; set; }
        //public object factoryDoorCode { get; set; }
        //public string entityPriceGrpSId { get; set; }
        //public string msgId { get; set; }
        //public object simDocNo { get; set; }
        //public string webAddress { get; set; }
        //public string firstName { get; set; }
        //public string familyName { get; set; }
        //public string email { get; set; }
        //public string docControllerDataCollection { get; set; }
        //public string serialInfoCollection { get; set; }
        //public string orderDCollection { get; set; }
        //public string orderD2Collection { get; set; }
        //public string orderDTaxCollection { get; set; }
        //public string checkUpdateOpenClose { get; set; }
        //public string iseInvoice { get; set; }
        //public string createUserId { get; set; }
        //public string updateUserId { get; set; }
        //public string createDate { get; set; }
        //public string updateDate { get; set; }
        //public string eInvAccIntegration { get; set; }
        //public string address1 { get; set; }
        //public string address2 { get; set; }
        //public string address3 { get; set; }
        //public string amt { get; set; }
        //public string amtDisc0 { get; set; }
        //public string amtDisc0Tra { get; set; }
        //public string amtDiscTotal { get; set; }
        //public string amtDiscTotalTra { get; set; }
        //public string amtOtv { get; set; }
        //public string amtOtvTra { get; set; }
        public string amtReceipt { get; set; }
        //public string amtReceiptTra { get; set; }
        //public string amtRound { get; set; }
        //public string amtRoundTra { get; set; }
        //public string amtTra { get; set; }
        //public string amtVat { get; set; }
        //public string amtVatDisc { get; set; }
        //public string amtVatDiscTra { get; set; }
        //public string amtVatTra { get; set; }
        //public string amtOtherTax { get; set; }
        //public string amtOtherTaxTra { get; set; }
        public string branchCode { get; set; }
        //public string branchDesc { get; set; }
        //public string branchId { get; set; }
        //public string catCode1 { get; set; }
        //public string catCode2 { get; set; }
        //public string catName1 { get; set; }
        //public string catName2 { get; set; }
        //public string catCode1Id { get; set; }
        //public string catCode2Id { get; set; }
        //public string cityId { get; set; }
        //public string cityName { get; set; }
        //public string countryId { get; set; }
        //public string countryName { get; set; }
        //public string curTraCode { get; set; }
        //public string isoCurTraCode { get; set; }
        //public string curRateTra { get; set; }
        //public string curRateTypeCode { get; set; }
        //public string curRateTypeId { get; set; }
        //public string disc0Id { get; set; }
        //public string disc0Rate { get; set; }
        //public string disc1Id { get; set; }
        //public string disc1Rate { get; set; }
        //public string disc2Id { get; set; }
        //public string disc2Rate { get; set; }
        //public string disc3Id { get; set; }
        //public string disc3Rate { get; set; }
        //public string isEnabled0 { get; set; }
        //public string isEnabled1 { get; set; }
        //public string discCalcType1 { get; set; }
        //public string isEnabled2 { get; set; }
        //public string discCalcType2 { get; set; }
        //public string isEnabled3 { get; set; }
        //public string discCalcType3 { get; set; }
        //public string discCalcType0 { get; set; }
        //public string isDocDifferentCur { get; set; }
        //public string discCode0 { get; set; }
        //public string discCode1 { get; set; }
        //public string discCode2 { get; set; }
        //public string discCode3 { get; set; }
        public DateTime docDate { get; set; }
        public string docNo { get; set; }
        //public string dueDate { get; set; }
        //public string dueDay { get; set; }
        //public string financeDueDate { get; set; }
        //public string financeDueDay { get; set; }
        //public string gnlNote1 { get; set; }
        //public string gnlNote10 { get; set; }
        //public string gnlNote2 { get; set; }
        //public string gnlNote3 { get; set; }
        //public string gnlNote4 { get; set; }
        //public string gnlNote5 { get; set; }
        //public string gnlNote6 { get; set; }
        //public string gnlNote7 { get; set; }
        //public string gnlNote8 { get; set; }
        //public string gnlNote9 { get; set; }
        //public string isPrinted { get; set; }
        //public string isInstalment { get; set; }
        public string note1 { get; set; }
        public string note2 { get; set; }
        public string note3 { get; set; }
        //public string paymentPlanCode { get; set; }
        //public string paymentPlanMId { get; set; }
        //public string salesPersonCode { get; set; }
        //public string salesPersonName { get; set; }
        //public string salesPersonId { get; set; }
        //public string shippingAddress1 { get; set; }
        //public string shippingAddress2 { get; set; }
        //public string shippingAddress3 { get; set; }
        //public string shippingAddressType { get; set; }
        //public string shippingCityId { get; set; }
        //public string shippingCountryId { get; set; }
        public string shippingCityName { get; set; }
        //public string shippingCountryName { get; set; }
        //public string shippingEntityId { get; set; }
        //public string shippingEntityCode { get; set; }
        //public string shippingEntityName { get; set; }
        //public string tel1 { get; set; }
        //public string shippingTownId { get; set; }
        public string shippingTownName { get; set; }
        //public string shippingZipCode { get; set; }
        public string sourceApp { get; set; }
        //public string sourceApp2 { get; set; }
        //public string sourceApp3 { get; set; }
        //public string sourceDId { get; set; }
        //public string sourceMId { get; set; }
        //public string townId { get; set; }
        //public string townName { get; set; }
        //public string vatDiscRate { get; set; }
        //public string vatDiscId { get; set; }
        //public string priceListId { get; set; }
        //public string zipCode { get; set; }
        //public string isEnabledVatDiscId { get; set; }
        //public string vatDiscCode { get; set; }
        //public string vatDiscOthInvType1 { get; set; }
        //public string docTraId { get; set; }
        public string docTraCode { get; set; }
        //public string inventoryStatus { get; set; }
        //public string isTransfer { get; set; }
        //public string voucherTempMId { get; set; }
        //public string docTraDesc { get; set; }
        //public string ebookDocumentType { get; set; }
        //public string gibExportRecord { get; set; }
        public string entityCode { get; set; }
        public string entityName { get; set; }
        //public string priceListCode { get; set; }
        //public string priceListDesc { get; set; }
        //public string shippingDate { get; set; }
        //public string coCode { get; set; }
        //public string coCurId { get; set; }
        //public string docNumberDId { get; set; }
        //public string ebookPaymentMethodBrowsable { get; set; }
        //public string purchaseSalesVal { get; set; }
        //public string finMNote1 { get; set; }
        //public string finMNote2 { get; set; }
        //public string finNote1 { get; set; }
        //public string finNote2 { get; set; }
        //public string accMNote1 { get; set; }
        //public string accMNote2 { get; set; }
        //public string accNote1 { get; set; }
        //public string accNote2 { get; set; }
        //public string priceAuthor { get; set; }
        //public string itemPriceAuthor { get; set; }
        //public string expensePriceAuthor { get; set; }
        //public string paymentAuthor { get; set; }
        //public string isBudgetTransfer { get; set; }
        //public string amtOiv { get; set; }
        //public string amtOivTra { get; set; }
        //public string shippingAddressTypeId { get; set; }
        //public string shippingAddressTypeCode { get; set; }
        //public string shippingAddressTypeDesc { get; set; }
        //public string isChangeVat { get; set; }
        //public string brCountryId { get; set; }
        //public string formContractMId { get; set; }
        //public string formContractCode { get; set; }
        //public string transportTypeId { get; set; }
        //public string transportTypeCode { get; set; }
        //public string transportTypeDesc { get; set; }
        //public string transportTypes { get; set; }
        //public string transporterId { get; set; }
        //public string transporterCode { get; set; }
        //public string transporterDesc { get; set; }
        //public string hasBrCountry { get; set; }
        //public string passSerialControlFromOrder { get; set; }
        //public string modified { get; set; }
        //public string senarioMod { get; set; }
        //public string promptValue { get; set; }
        //public string promptValues { get; set; }
        //public string justUpdate { get; set; }
        //public object controlProperties { get; set; }
        //public object uyumObjectContainerCollection { get; set; }
        //public string parent { get; set; }
        //public string dynamicValues { get; set; }
        //public string guid { get; set; }
        //public string extendedObjects { get; set; }
    }

    public class Order_D
    {
        public string orderD2Collection { get; set; }
        public string isNotControlFreeQty { get; set; }
        public string noteLarge { get; set; }
        public string preCostMId { get; set; }
        public string preCostRefNo { get; set; }
        public string prePrice { get; set; }
        public string preCurTraId { get; set; }
        public string toleranceRate { get; set; }
        public string salesOrderDocNoForWorder { get; set; }
        public string salesOrderForWorderStatus { get; set; }
        public string salesOrderStatus { get; set; }
        public string salesOrderDocNo { get; set; }
        public string salesOrderItemCode { get; set; }
        public string salesOrderItemCodeForWrd { get; set; }
        public string salesOrderItemNameForWrd { get; set; }
        public string salesOrderItemName { get; set; }
        public string contractGroupId { get; set; }
        public string itemCatCode1Id { get; set; }
        public string bomOrderDId { get; set; }
        public string configurationMId { get; set; }
        public string configurationNo { get; set; }
        public string isBom { get; set; }
        public string checkUpdateOpenClose { get; set; }
        public string entityOrderRefId { get; set; }
        public string salesOrderDocNoForEntityOrderRef { get; set; }
        public string transitOrderDId { get; set; }
        public string transitOrderMId { get; set; }
        public string isTransitOrder { get; set; }
        public string configSourceType { get; set; }
        public string loadingCardId { get; set; }
        public object loadingCardCode { get; set; }
        public object loadingCardDesc { get; set; }
        public string unitPriceTraMax { get; set; }
        public string unitPriceTraMin { get; set; }
        public string sourceOrderMId { get; set; }
        public string sourceOrderDId { get; set; }
        public string coId { get; set; }
        public string branchId { get; set; }
        public string purchaseSales { get; set; }
        public string orderStatus { get; set; }
        public string propertyKey { get; set; }
        public string lineType { get; set; }
        public string reservationType { get; set; }
        public string id { get; set; }
        public string branchCode { get; set; }
        public string coCode { get; set; }
        public string deliveryDate { get; set; }
        public string catDesc1 { get; set; }
        public string catDesc2 { get; set; }
        public string colorDesc { get; set; }
        public string curRateTypeDesc { get; set; }
        public string curTraDesc { get; set; }
        public string discDesc1 { get; set; }
        public string discDesc2 { get; set; }
        public string discDesc3 { get; set; }
        public string itemGnlAttributeDesc1 { get; set; }
        public string itemGnlAttributeDesc2 { get; set; }
        public string itemGnlAttributeDesc3 { get; set; }
        public string lotDesc { get; set; }
        public string otvDesc { get; set; }
        public string otvMaktuDesc { get; set; }
        public string packageTypeDesc { get; set; }
        public string paymentPlanDesc { get; set; }
        public string projectDesc { get; set; }
        public string qualityDesc { get; set; }
        public string routeDesc { get; set; }
        public string vatDesc { get; set; }
        public string autoOrderType { get; set; }
        public string vatDiscDesc { get; set; }
        public string qtyAfterSalesPurchaseBwhItem { get; set; }
        public string unitPriceWithDisc { get; set; }
        public string qtyPrmBwhItem { get; set; }
        public string qtySOBwhItem { get; set; }
        public string qtyPOBwhItem { get; set; }
        public string detailShipment { get; set; }
        public string entityOrderDate { get; set; }
        public string entityRequestDate { get; set; }
        public string entityOrderNo { get; set; }
        public string orderMId { get; set; }
        public string qtyDemand { get; set; }
        public string qtyCustoms { get; set; }
        public string qtyRejected { get; set; }
        public string qtyReserved { get; set; }
        public string qtyShipping { get; set; }
        public string qtyReferralTotal { get; set; }
        public string routeCode { get; set; }
        public string routeMId { get; set; }
        public string shippingDate { get; set; }
        public string qtyFile { get; set; }
        public string qtyOnRoad { get; set; }
        public string unitDesc { get; set; }
        public string requestStatus { get; set; }
        public string approvalStatusId { get; set; }
        public string approvalStatusCode { get; set; }
        public string requestEstimatedUnitPrice { get; set; }
        public string requestDocDate { get; set; }
        public string requestDocNo { get; set; }
        public string requestUserName { get; set; }
        public string offerDocNo { get; set; }
        public string woOutsideMId { get; set; }
        public string woOutsideDocDate { get; set; }
        public string woOutsideDocNo { get; set; }
        public string woOutsideDId { get; set; }
        public string woOutsideLineNo { get; set; }
        public string operationId { get; set; }
        public string operationCode { get; set; }
        public string operationDesc { get; set; }
        public string operationNo { get; set; }
        public string wstationId { get; set; }
        public string wstationCode { get; set; }
        public string wstationDescription { get; set; }
        public string woOutsideType { get; set; }
        public string entityId { get; set; }
        public string isAutoOrdered { get; set; }
        public string entityItemCode { get; set; }
        public string isEditable { get; set; }
        public string confSelectionsMId { get; set; }
        public string tempQty { get; set; }
        public string shippingEntityId { get; set; }
        public string shippingAddressTypeId { get; set; }
        public string shippingAddress1 { get; set; }
        public string shippingAddress2 { get; set; }
        public string shippingAddress3 { get; set; }
        public string shippingCityName { get; set; }
        public string shippingTownName { get; set; }
        public string shippingCountryName { get; set; }
        public string qtyTotalOpenReferralOrder { get; set; }
        public string docNo { get; set; }
        public string masterNote1 { get; set; }
        public string entityMId { get; set; }
        public string entityName { get; set; }
        public string entityCode { get; set; }
        public string paymentMethodId { get; set; }
        public string qtyFactorForPackage { get; set; }
        public string abtEnableDisable { get; set; }
        public string lockForReferralOrderMode { get; set; }
        public string lockForPartialShippingOrderMode { get; set; }
        public string allowItemPropertyFieldsIfReferralOrdered { get; set; }
        public string allowUpdateIfNoShippingOrReferralOrder { get; set; }
        public string lockForClosedOrderLine { get; set; }
        public string fromMasterUpdate { get; set; }
        public string qtyRemaining { get; set; }
        public string salesPersonId { get; set; }
        public string salesPersonCode { get; set; }
        public string salesPersonName { get; set; }
        public string currencyOption { get; set; }
        public string freePrmMId { get; set; }
        public string freeSecMId { get; set; }
        public string freePrmMCode { get; set; }
        public string freeSecMCode { get; set; }
        public string defaultAsortMode { get; set; }
        public string lastAsortMode { get; set; }
        public string allocationsMId { get; set; }
        public string allocationsCode { get; set; }
        public string rate { get; set; }
        public string unit2Id { get; set; }
        public string unit2Code { get; set; }
        public string qty2 { get; set; }
        public string unitFactor { get; set; }
        public object itemClassCode { get; set; }
        public string previousId { get; set; }
        public string dimInfo { get; set; }
        public string formContractNote { get; set; }
        public string itemNameManual { get; set; }
        public string createUserId { get; set; }
        public string updateUserId { get; set; }
        public string createDate { get; set; }
        public string updateDate { get; set; }
        public string amt { get; set; }
        public string amtCalcType { get; set; }
        public string amtDisc0 { get; set; }
        public string amtDisc { get; set; }
        public string amtWithDisc { get; set; }
        public string amtDisc1 { get; set; }
        public string amtDisc2 { get; set; }
        public string amtDisc3 { get; set; }
        public string amtDisc4 { get; set; }
        public string amtDisc5 { get; set; }
        public string amtDisc6 { get; set; }
        public string amtMaktuOtv { get; set; }
        public string amtOtv { get; set; }
        public string amtOiv { get; set; }
        public string amtTra { get; set; }
        public string amtVat { get; set; }
        public string amtVatDisc { get; set; }
        public string curTraCode { get; set; }
        public string curRateTra { get; set; }
        public string curRateTypeCode { get; set; }
        public string curRateTypeId { get; set; }
        public string curTraId { get; set; }
        public string disc1Id { get; set; }
        public string disc1Rate { get; set; }
        public string disc2Id { get; set; }
        public string disc2Rate { get; set; }
        public string disc3Id { get; set; }
        public string disc3Rate { get; set; }
        public string discCode1 { get; set; }
        public string discDescription1 { get; set; }
        public string discCode2 { get; set; }
        public string discDescription2 { get; set; }
        public string discCode3 { get; set; }
        public string discDescription3 { get; set; }
        public string otvId { get; set; }
        public string oivId { get; set; }
        public string otvMaktuId { get; set; }
        public string qty { get; set; }
        public string qtyFreePrm { get; set; }
        public string qtyFreeSec { get; set; }
        public string qtyPrm { get; set; }
        public string otvCode { get; set; }
        public string oivCode { get; set; }
        public string otvMaktuCode { get; set; }
        public string vatCode { get; set; }
        public string vatName { get; set; }
        public string vatRate { get; set; }
        public string otvRate { get; set; }
        public string oivRate { get; set; }
        public string vatDiscCode { get; set; }
        public string otherInvoiceDeclaration { get; set; }
        public string otherInvoiceDeclaration2 { get; set; }
        public string vatDiscOtherInvTypeCode { get; set; }
        public string vatDiscOtherInvTypeCode2 { get; set; }
        public string unitPrice { get; set; }
        public string unitPriceTra { get; set; }
        public string vatDiscRate { get; set; }
        public string vatDiscId { get; set; }
        public string vatId { get; set; }
        public string vatStatus { get; set; }
        public string docDate { get; set; }
        public string dueDate { get; set; }
        public string dueDay { get; set; }
        public string analysisCode { get; set; }
        public string analysisDesc { get; set; }
        public string analysisId { get; set; }
        public string bomMId { get; set; }
        public string alternativeNo { get; set; }
        public string bomRevNo { get; set; }
        public string bomMDesc { get; set; }
        public string branchDesc { get; set; }
        public string bwhDesc { get; set; }
        public string whouseCode { get; set; }
        public string catCode1 { get; set; }
        public string catDescription1 { get; set; }
        public string catCode2 { get; set; }
        public string catDescription2 { get; set; }
        public string catCode1Id { get; set; }
        public string catCode2Id { get; set; }
        public string colorCode { get; set; }
        public string colorId { get; set; }
        public string costCenterDesc { get; set; }
        public string costCenterCode { get; set; }
        public string costCenterId { get; set; }
        public string dcardId { get; set; }
        public string dcardCode { get; set; }
        public string isConfigurable { get; set; }
        public string dcardName { get; set; }
        public string dcardCode2 { get; set; }
        public string dcardName2 { get; set; }
        public string isEnabled1Id { get; set; }
        public string discCalcType1 { get; set; }
        public string isEnabled2Id { get; set; }
        public string discCalcType2 { get; set; }
        public string isEnabled3Id { get; set; }
        public string discCalcType3 { get; set; }
        public string isEnabledVatId { get; set; }
        public string isEnabledVatDiscId { get; set; }
        public string isEnabledOtvId { get; set; }
        public string isEnabledOivId { get; set; }
        public string isEnabledMaktuOtvId { get; set; }
        public string entityItemId { get; set; }
        public string gainLossTypeCode { get; set; }
        public string gainLossTypeDesc { get; set; }
        public string gainLossTypeId { get; set; }
        public string itemAttribute1Id { get; set; }
        public string itemAttribute2Id { get; set; }
        public string itemAttribute3Id { get; set; }
        public string itemAttributeCode1 { get; set; }
        public string itemAttributeDesc1 { get; set; }
        public string itemAttributeDesc2 { get; set; }
        public string itemAttributeDesc3 { get; set; }
        public string weight { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string depth { get; set; }
        public string diameter { get; set; }
        public string itemAttributeCode2 { get; set; }
        public string itemAttributeCode3 { get; set; }
        public string itemGnlAttributeCode1 { get; set; }
        public string itemGnlAttributeCode2 { get; set; }
        public string itemGnlAttributeCode3 { get; set; }
        public string itemGnlAttribute1Id { get; set; }
        public string itemGnlAttribute2Id { get; set; }
        public string itemGnlAttribute3Id { get; set; }
        public string itemId { get; set; }
        public string lineNo { get; set; }
        public string lotCode { get; set; }
        public string lotId { get; set; }
        public string note1 { get; set; }
        public string note2 { get; set; }
        public string note3 { get; set; }
        public string packageTypeCode { get; set; }
        public string packageTypeId { get; set; }
        public string paymentPlanCode { get; set; }
        public string paymentPlanId { get; set; }
        public string projectCode { get; set; }
        public string projectMId { get; set; }
        public string qualityCode { get; set; }
        public string qualityId { get; set; }
        public string serialNo { get; set; }
        public string sourceApp { get; set; }
        public string sourceApp2 { get; set; }
        public string sourceApp3 { get; set; }
        public string sourceDId { get; set; }
        public string sourceD2Id { get; set; }
        public string sourceD3Id { get; set; }
        public string sourceMId { get; set; }
        public string unitId { get; set; }
        public string unitCode { get; set; }
        public string reasonId { get; set; }
        public string reasonCode { get; set; }
        public string whouseId { get; set; }
        public string accId { get; set; }
        public string expenseId { get; set; }
        public string registerId { get; set; }
        public string contactId { get; set; }
        public string registerFullName { get; set; }
        public string contactCode { get; set; }
        public string contactName { get; set; }
        public string priceListDId { get; set; }
        public string qtyButton { get; set; }
        public string priceButton { get; set; }
        public string priceCostButton { get; set; }
        public string tempId { get; set; }
        public string vatDiscCalcType { get; set; }
        public string isDetailed { get; set; }
        public string isWaybilShred { get; set; }
        public string priceListId { get; set; }
        public string priceListCode { get; set; }
        public string vatBInclude { get; set; }
        public string impAccId { get; set; }
        public string taxTemplateMId { get; set; }
        public string taxTemplateName { get; set; }
        public string formContractMId { get; set; }
        public string formContractCode { get; set; }
        public string description { get; set; }
        public string amtDisc0Tra { get; set; }
        public string amtDisc1Tra { get; set; }
        public string amtDisc2Tra { get; set; }
        public string amtDisc3Tra { get; set; }
        public string amtDisc4Tra { get; set; }
        public string amtDisc5Tra { get; set; }
        public string amtDisc6Tra { get; set; }
        public string amtDiscTra { get; set; }
        public string amtWithDiscTra { get; set; }
        public string amtWithDiscTraForUnit { get; set; }
        public string activityId { get; set; }
        public string activityCode { get; set; }
        public string activityDesc { get; set; }
        public string freePrmImportant { get; set; }
        public string sourceDIdFrActivity { get; set; }
        public string sourceAppFrActivity { get; set; }
        public string calcUnitPriceFromAmt { get; set; }
        public string statisticRecord { get; set; }
        public string oivStatisticId { get; set; }
        public string priceList0DId { get; set; }
        public string priceList0Id { get; set; }
        public string unitPriceTra0 { get; set; }
        public string itemAttribute4Id { get; set; }
        public object itemAttributeCode4 { get; set; }
        public string itemAttribute5Id { get; set; }
        public object itemAttributeCode5 { get; set; }
        public string itemAttribute6Id { get; set; }
        public object itemAttributeCode6 { get; set; }
        public string itemAttribute7Id { get; set; }
        public object itemAttributeCode7 { get; set; }
        public string itemAttribute8Id { get; set; }
        public object itemAttributeCode8 { get; set; }
        public string itemAttribute9Id { get; set; }
        public object itemAttributeCode9 { get; set; }
        public string itemAttribute10Id { get; set; }
        public object itemAttributeCode10 { get; set; }
        public string itemAttribute11Id { get; set; }
        public object itemAttributeCode11 { get; set; }
        public string itemAttribute12Id { get; set; }
        public object itemAttributeCode12 { get; set; }
        public string itemAttribute13Id { get; set; }
        public object itemAttributeCode13 { get; set; }
        public string itemAttribute14Id { get; set; }
        public object itemAttributeCode14 { get; set; }
        public string itemAttribute15Id { get; set; }
        public object itemAttributeCode15 { get; set; }
        public string itemAttribute16Id { get; set; }
        public object itemAttributeCode16 { get; set; }
        public string itemAttribute17Id { get; set; }
        public object itemAttributeCode17 { get; set; }
        public string itemAttribute18Id { get; set; }
        public object itemAttributeCode18 { get; set; }
        public string itemAttribute19Id { get; set; }
        public object itemAttributeCode19 { get; set; }
        public string itemAttribute20Id { get; set; }
        public object itemAttributeCode20 { get; set; }
        public string qtyNotDetailed { get; set; }
        public string dontExecuteBwhData { get; set; }
        public string abtBudgetD2Id { get; set; }
        public string abtGainLoss { get; set; }
        public string abtBudgetMId { get; set; }
        public string abtBudgetId { get; set; }
        public string abtActId { get; set; }
        public string abtBudgetCode { get; set; }
        public string abtBudgetDesc { get; set; }
        public string abtActCode { get; set; }
        public string abtActDesc { get; set; }
        public string modified { get; set; }
        public string senarioMod { get; set; }
        public string promptValue { get; set; }
        public string promptValues { get; set; }
        public string justUpdate { get; set; }
        public object controlProperties { get; set; }
        public object uyumObjectContainerCollection { get; set; }
        public string parent { get; set; }
        public string dynamicValues { get; set; }
        public string guid { get; set; }
        public string extendedObjects { get; set; }
    }

}