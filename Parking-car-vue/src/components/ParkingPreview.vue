<template>
    <div class="mt-8">
      <h2 class="text-xl font-semibold mb-4">lสัส</h2>
      <div class="border rounded-xl p-6 bg-red-500">
        <p><strong>ทะเบียน:</strong> {{ form.plateNumber }}</p>
        <p><strong>ชื่อคนขับ:</strong> {{ form.driverName }}</p>
        <p><strong>สีรถ:</strong> {{ form.carColor }}</p>
        <p><strong>ประเภทรถ:</strong> {{ form.carType }}</p>
        <p><strong>เวลาเข้า:</strong> {{ form.entryTime }}</p>
        <p><strong>เวลาออก:</strong> {{ form.exitTime }}</p>
        <p><strong>ราคา:</strong> {{ form.price }}</p>
      </div>
    </div>
  </template>
  
  <script setup lang="ts">
  defineProps<{
    form: any
  }>()
  </script>
  