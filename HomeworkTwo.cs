namespace PrincipleSOLID
{
    #region Задание 1
    //1.	Применить принцип открытости / закрытости. 
    //Класс OrderRepository изначально был реализован для работы с заказами, хранящимися в MySQL.
    //Но однажды нам потребовалось реализовать работу с данными о заказах, например, через API стороннего веб-сервиса.
    //Какие изменения нам надо будет внести?

    #region Пример
    //class Order
    //{
    //    int orderId;
    //    string Name;
    //}
    //class OrderRepository
    //{
    //    public Order Load(int orderId) { return ... }
    //    public void Save(Order order) { ... }
    //    public void Update(Order order) { ... }
    //    public void Delete(Order order) { ... }
    //}
    #endregion

    class Order
    {
        int orderId;
        string Name;
    }
    class OrderRepository
    {
        public virtual Order Load(int orderId) { return ... }
        public virtual void Save(Order order) { ... }
        public virtual void Update(Order order) { ... }
        public virtual void Delete(Order order) { ... }
    }
    class MySQLRepository : OrderRepository
    {
        public override Order Load(int orderId) { return ... }
        public override void Save(Order order) { ... }
        public override void Update(Order order) { ... }
        public override void Delete(Order order) { ... }
    }
    class APIRepository : OrderRepository
    {
        public override Order Load(int orderId) { return ... }
        public override void Save(Order order) { ... }
        public override void Update(Order order) { ... }
        public override void Delete(Order order) { ... }
    }

    #endregion

    #region Задание 2
    //2.	Принцип разделения интерфейсов.
    //Товары в магазине могут иметь промокод, скидку, у них есть цена, состояние и т.д. Если этот товар – одежда,
    //для неё устанавливается материал, из которого она сделана, её цвет и размер. Какие изменения нужно внести в код,
    //чтобы описать произвольные товары (книги, автомобили и т. п.), соблюдая принципы SOLID?

    #region Пример

    //interface IItem
    //{
    //    void SetDiscount(double discount);
    //    void SetPromocode(string promocode);

    //    void SetColor(Color color);
    //    void SetSize(Size size);

    //    void SetPrice(double price);
    //}
    //class Clothes : IItem
    //{
    //    public void SetColor(Color color) { }
    //    public void SetDiscount(double discount) { }
    //    public void SetPrice(double price) { }
    //    public void SetPromocode(string promocode) { }
    //    public void SetSize(Size size) { }
    //}

    #endregion

    interface IPromocode
    {
        void SetPromocode(string promocode);
    }
    interface IDiscount
    {
        void SetDiscount(double discount);
    }
    interface IItem
    {
        int itemId { get; set; }
        void SetPrice(double price);
    }
    interface IClothes
    {
        void SetColor(Color color);
        void SetSize(Size size);
    }
    interface IBook
    {
        void SetAuthor(string author);
        void SetTitle(string title);
    }
    interface ICar
    {
        void SetBrand(string brand);
        void SetName(string name);
        void SetBodyType(string bodyType);
        void SetColor(Color color);
        void SetSpeed(int speed);
    }
    class Clothes : IItem, IClothes, IPromocode, IDiscount
    {
        int IItem.itemId { get; set; }

        public void SetPromocode(string promocode) { }
        public void SetDiscount(double discount) { }
        public void SetColor(Color color) { }
        public void SetSize(Size size) { }
        public void SetPrice(double price) { }
    }

    #endregion
}
