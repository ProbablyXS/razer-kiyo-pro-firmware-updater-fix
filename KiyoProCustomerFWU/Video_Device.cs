using System;

// Token: 0x02000002 RID: 2
internal struct Video_Device
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public Video_Device(int ID, string Name, Guid Identity = default(Guid))
	{
		this.Device_ID = ID;
		this.Device_Name = Name;
		this.Identifier = Identity;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002067 File Offset: 0x00000267
	public override string ToString()
	{
		return string.Format("[{0}] {1}: {2}", this.Device_ID, this.Device_Name, this.Identifier);
	}

	// Token: 0x04000001 RID: 1
	public string Device_Name;

	// Token: 0x04000002 RID: 2
	public int Device_ID;

	// Token: 0x04000003 RID: 3
	public Guid Identifier;
}
