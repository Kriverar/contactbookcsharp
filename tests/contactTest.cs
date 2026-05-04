using ContactBook;

namespace ContactBook.Tests;

public class ContactTests
{
    [Fact]
    public void Constructor_WithNoArguments_ShouldCreateEmptyContact()
    {
        Contact contact = new Contact();

        Assert.Equal("", contact.GetFName());
        Assert.Equal("", contact.GetLName());
        Assert.Equal("", contact.GetPhone());
        Assert.Equal("", contact.GetEmail());
    }

    [Fact]
    public void Constructor_WithArguments_ShouldSetAllFields()
    {
        Contact contact = new Contact("John", "Doe", "787-555-1234", "john@example.com");

        Assert.Equal("John", contact.GetFName());
        Assert.Equal("Doe", contact.GetLName());
        Assert.Equal("787-555-1234", contact.GetPhone());
        Assert.Equal("john@example.com", contact.GetEmail());
    }

    [Fact]
    public void SetFname_ShouldUpdateFirstName()
    {
        Contact contact = new Contact();

        contact.SetFname("Kristian");

        Assert.Equal("Kristian", contact.GetFName());
    }

    [Fact]
    public void SetLname_ShouldUpdateLastName()
    {
        Contact contact = new Contact();

        contact.SetLname("Rivera");

        Assert.Equal("Rivera", contact.GetLName());
    }

    [Fact]
    public void SetPhone_ShouldUpdatePhone()
    {
        Contact contact = new Contact();

        contact.SetPhone("787-000-1111");

        Assert.Equal("787-000-1111", contact.GetPhone());
    }

    [Fact]
    public void SetEmail_ShouldUpdateEmail()
    {
        Contact contact = new Contact();

        contact.SetEmail("test@email.com");

        Assert.Equal("test@email.com", contact.GetEmail());
    }

    [Fact]
    public void Setters_ShouldAllowEmptyStrings()
    {
        Contact contact = new Contact("John", "Doe", "123", "john@example.com");

        contact.SetFname("");
        contact.SetLname("");
        contact.SetPhone("");
        contact.SetEmail("");

        Assert.Equal("", contact.GetFName());
        Assert.Equal("", contact.GetLName());
        Assert.Equal("", contact.GetPhone());
        Assert.Equal("", contact.GetEmail());
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        Contact contact = new Contact("John", "Doe", "787-555-1234", "john@example.com");

        string result = contact.ToString();

        Assert.Equal("Contact[fname=John, lname=Doe, phone=787-555-1234, email=john@example.com]", result);
    }

    [Fact]
    public void Equals_WithSameValues_ShouldReturnTrue()
    {
        Contact contact1 = new Contact("John", "Doe", "787-555-1234", "john@example.com");
        Contact contact2 = new Contact("John", "Doe", "787-555-1234", "john@example.com");

        Assert.True(contact1.Equals(contact2));
    }

    [Fact]
    public void Equals_WithDifferentFirstName_ShouldReturnFalse()
    {
        Contact contact1 = new Contact("John", "Doe", "787-555-1234", "john@example.com");
        Contact contact2 = new Contact("Jane", "Doe", "787-555-1234", "john@example.com");

        Assert.False(contact1.Equals(contact2));
    }

    [Fact]
    public void Equals_WithDifferentLastName_ShouldReturnFalse()
    {
        Contact contact1 = new Contact("John", "Doe", "787-555-1234", "john@example.com");
        Contact contact2 = new Contact("John", "Smith", "787-555-1234", "john@example.com");

        Assert.False(contact1.Equals(contact2));
    }

    [Fact]
    public void Equals_WithDifferentPhone_ShouldReturnFalse()
    {
        Contact contact1 = new Contact("John", "Doe", "787-555-1234", "john@example.com");
        Contact contact2 = new Contact("John", "Doe", "787-000-0000", "john@example.com");

        Assert.False(contact1.Equals(contact2));
    }

    [Fact]
    public void Equals_WithDifferentEmail_ShouldReturnFalse()
    {
        Contact contact1 = new Contact("John", "Doe", "787-555-1234", "john@example.com");
        Contact contact2 = new Contact("John", "Doe", "787-555-1234", "other@example.com");

        Assert.False(contact1.Equals(contact2));
    }

    [Fact]
    public void Equals_WithNullContact_ShouldReturnFalse()
    {
        Contact contact = new Contact("John", "Doe", "787-555-1234", "john@example.com");

        Assert.False(contact.Equals(null));
    }

    [Fact]
    public void Equals_WithSameReference_ShouldReturnTrue()
    {
        Contact contact = new Contact("John", "Doe", "787-555-1234", "john@example.com");

        Assert.True(contact.Equals(contact));
    }

    [Fact]
    public void EqualsObject_WithSameValues_ShouldReturnTrue()
    {
        Contact contact1 = new Contact("John", "Doe", "787-555-1234", "john@example.com");
        object contact2 = new Contact("John", "Doe", "787-555-1234", "john@example.com");

        Assert.True(contact1.Equals(contact2));
    }

    [Fact]
    public void EqualsObject_WithDifferentType_ShouldReturnFalse()
    {
        Contact contact = new Contact("John", "Doe", "787-555-1234", "john@example.com");

        Assert.False(contact.Equals("not a contact"));
    }

    [Fact]
    public void EqualOperator_WithSameValues_ShouldReturnTrue()
    {
        Contact contact1 = new Contact("John", "Doe", "787-555-1234", "john@example.com");
        Contact contact2 = new Contact("John", "Doe", "787-555-1234", "john@example.com");

        Assert.True(contact1 == contact2);
    }

    [Fact]
    public void EqualOperator_WithDifferentValues_ShouldReturnFalse()
    {
        Contact contact1 = new Contact("John", "Doe", "787-555-1234", "john@example.com");
        Contact contact2 = new Contact("Jane", "Doe", "787-555-1234", "john@example.com");

        Assert.False(contact1 == contact2);
    }

    [Fact]
    public void EqualOperator_WithBothNull_ShouldReturnTrue()
    {
        Contact? contact1 = null;
        Contact? contact2 = null;

        Assert.True(contact1 == contact2);
    }

    [Fact]
    public void EqualOperator_WithLeftNull_ShouldReturnFalse()
    {
        Contact? contact1 = null;
        Contact contact2 = new Contact("John", "Doe", "787-555-1234", "john@example.com");

        Assert.False(contact1 == contact2);
    }

    [Fact]
    public void EqualOperator_WithRightNull_ShouldReturnFalse()
    {
        Contact contact1 = new Contact("John", "Doe", "787-555-1234", "john@example.com");
        Contact? contact2 = null;

        Assert.False(contact1 == contact2);
    }

    [Fact]
    public void NotEqualOperator_WithSameValues_ShouldReturnFalse()
    {
        Contact contact1 = new Contact("John", "Doe", "787-555-1234", "john@example.com");
        Contact contact2 = new Contact("John", "Doe", "787-555-1234", "john@example.com");

        Assert.False(contact1 != contact2);
    }

    [Fact]
    public void NotEqualOperator_WithDifferentValues_ShouldReturnTrue()
    {
        Contact contact1 = new Contact("John", "Doe", "787-555-1234", "john@example.com");
        Contact contact2 = new Contact("Jane", "Doe", "787-555-1234", "john@example.com");

        Assert.True(contact1 != contact2);
    }

    [Fact]
    public void GetHashCode_WithSameValues_ShouldReturnSameHashCode()
    {
        Contact contact1 = new Contact("John", "Doe", "787-555-1234", "john@example.com");
        Contact contact2 = new Contact("John", "Doe", "787-555-1234", "john@example.com");

        Assert.Equal(contact1.GetHashCode(), contact2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_WithDifferentValues_ShouldUsuallyReturnDifferentHashCode()
    {
        Contact contact1 = new Contact("John", "Doe", "787-555-1234", "john@example.com");
        Contact contact2 = new Contact("Jane", "Smith", "787-000-0000", "jane@example.com");

        Assert.NotEqual(contact1.GetHashCode(), contact2.GetHashCode());
    }
}